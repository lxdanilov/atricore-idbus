package org.atricore.idbus.capabilities.samlr2.main.claims.producers;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.atricore.idbus.capabilities.samlr2.main.SamlR2Exception;
import org.atricore.idbus.capabilities.samlr2.main.claims.SamlR2ClaimsMediator;
import org.atricore.idbus.capabilities.samlr2.main.claims.SamlR2ClaimsRequest;
import org.atricore.idbus.capabilities.samlr2.main.claims.SamlR2ClaimsResponse;
import org.atricore.idbus.capabilities.samlr2.main.common.plans.SamlR2PlanningConstants;
import org.atricore.idbus.capabilities.samlr2.main.common.producers.SamlR2Producer;
import org.atricore.idbus.capabilities.samlr2.support.SAMLR2Constants;
import org.atricore.idbus.capabilities.samlr2.support.SAMLR2MessagingConstants;
import org.atricore.idbus.capabilities.samlr2.support.auth.AuthnCtxClass;
import org.atricore.idbus.capabilities.samlr2.support.binding.SamlR2Binding;
import org.atricore.idbus.kernel.main.authn.Constants;
import org.atricore.idbus.kernel.main.federation.metadata.EndpointDescriptor;
import org.atricore.idbus.kernel.main.federation.metadata.EndpointDescriptorImpl;
import org.atricore.idbus.kernel.main.mediation.Channel;
import org.atricore.idbus.kernel.main.mediation.MediationMessageImpl;
import org.atricore.idbus.kernel.main.mediation.camel.AbstractCamelEndpoint;
import org.atricore.idbus.kernel.main.mediation.camel.component.binding.CamelMediationExchange;
import org.atricore.idbus.kernel.main.mediation.camel.component.binding.CamelMediationMessage;
import org.atricore.idbus.kernel.main.mediation.claim.*;
import org.atricore.idbus.kernel.main.mediation.endpoint.IdentityMediationEndpoint;
import org.oasis_open.docs.wss._2004._01.oasis_200401_wss_wssecurity_secext_1_0.AttributedString;
import org.oasis_open.docs.wss._2004._01.oasis_200401_wss_wssecurity_secext_1_0.UsernameTokenType;

import javax.xml.namespace.QName;
import java.io.IOException;

/**
 * @author <a href=mailto:sgonzalez@atricore.org>Sebastian Gonzalez Oyuela</a>
 */
public class UsernamePasscodeClaimsProducer extends SamlR2Producer
        implements SAMLR2Constants, SAMLR2MessagingConstants, SamlR2PlanningConstants {

    private static final Log logger = LogFactory.getLog(UsernamePasscodeClaimsProducer.class);

    public UsernamePasscodeClaimsProducer( AbstractCamelEndpoint<CamelMediationExchange> endpoint ) throws Exception {
        super( endpoint );
    }

    @Override
    protected void doProcess ( CamelMediationExchange exchange) throws Exception {

        if (logger.isDebugEnabled())
            logger.debug("Collecting Passcode claims");

        CamelMediationMessage in = (CamelMediationMessage) exchange.getIn();

        // -------------------------------------------------------------------------
        // Collect claims
        // -------------------------------------------------------------------------
        if (logger.isDebugEnabled())
            logger.debug("Starting to collect passcode claims");
        SamlR2ClaimsRequest claimsRequest = (SamlR2ClaimsRequest) in.getMessage().getContent();

        if (logger.isDebugEnabled())
            logger.debug("Storing claims request as local variable, id:" + claimsRequest.getId());
        in.getMessage().getState().setLocalVariable("urn:org:atricore:idbus:claims-request", claimsRequest);
        doProcessClaimsRequest(exchange, claimsRequest);

    }

    @Override
    protected void doProcessResponse(CamelMediationExchange exchange) throws Exception {
        // -------------------------------------------------------------------------
        // Process collected claims
        // -------------------------------------------------------------------------
        if (logger.isDebugEnabled())
            logger.debug("Received username/passcode claims");

        CamelMediationMessage in = (CamelMediationMessage) exchange.getIn();

        ClaimsResponse claimsResponse = (ClaimsResponse) in.getMessage().getContent();
        ClaimsRequest claimsRequest = (ClaimsRequest) in.getMessage().getState().getLocalVariable("urn:org:atricore:idbus:claims-request");
        if (claimsRequest == null)
            throw new IllegalStateException("Claims request not found!");

        if (logger.isDebugEnabled())
            logger.debug("Recovered claims request from local variable, id:" + claimsRequest.getId());

        doProcessReceivedClaims(exchange, claimsRequest, claimsResponse.getClaimSet());

    }

    protected void doProcessClaimsRequest(CamelMediationExchange exchange, ClaimsRequest claimsRequest) throws IOException {

        SamlR2ClaimsMediator mediator = (SamlR2ClaimsMediator)channel.getIdentityMediator();
        CamelMediationMessage in = (CamelMediationMessage) exchange.getIn();

        EndpointDescriptor ed = new EndpointDescriptorImpl(
                "BasicAuthnLoginForm",
                "BasicAuthnLoginForm",
                SamlR2Binding.SSO_ARTIFACT.getValue(),
                mediator.getBasicAuthnUILocation(),
                null);

        CamelMediationMessage out = (CamelMediationMessage) exchange.getOut();

        out.setMessage(
                new MediationMessageImpl(claimsRequest.getId(),
                        claimsRequest,
                        "ClaimsRequest",
                        null,
                        ed,
                        in.getMessage().getState())
        );

        exchange.setOut(out);

    }

    protected void doProcessReceivedClaims(CamelMediationExchange exchange,
                                           ClaimsRequest claimsRequest,
                                           ClaimSet receivedClaims) throws Exception {

        CamelMediationMessage in = (CamelMediationMessage) exchange.getIn();
        SamlR2ClaimsMediator mediator = ((SamlR2ClaimsMediator ) channel.getIdentityMediator());

        // This is the binding we're using to send the response
        SamlR2Binding binding = SamlR2Binding.SSO_ARTIFACT;
        Channel issuer = claimsRequest.getIssuerChannel();

        IdentityMediationEndpoint claimsProcessingEndpoint = null;

        // Look for an endpoint to send the response
        for (IdentityMediationEndpoint endpoint : issuer.getEndpoints()) {
            if (endpoint.getType().equals(claimsRequest.getIssuerEndpoint().getType()) &&
                    endpoint.getBinding().equals(binding.getValue())) {
                claimsProcessingEndpoint = endpoint;
                break;
            }
        }

        if (claimsProcessingEndpoint == null) {
            throw new SamlR2Exception("No endpoint supporting " + binding + " of type " +
                    claimsRequest.getIssuerEndpoint().getType() + " found in channel " + claimsRequest.getIssuerChannel().getName());
        }

        EndpointDescriptor ed = mediator.resolveEndpoint(claimsRequest.getIssuerChannel(),
                claimsProcessingEndpoint);

        String passcode = null;
        String username = null;

        // Addapt received simple claims to SAMLR Required token
        for (Claim c : receivedClaims.getClaims()) {

            if (c.getQualifier().equalsIgnoreCase("username"))
                username = (String) c.getValue();

            if (c.getQualifier().equalsIgnoreCase("passcode"))
                passcode = (String) c.getValue();
        }

        // Build a SAMLR2 Compatible Security token
        UsernameTokenType usernameToken = new UsernameTokenType ();
        AttributedString usernameString = new AttributedString();
        usernameString.setValue( username );

        usernameToken.setUsername( usernameString );
        usernameToken.getOtherAttributes().put( new QName( Constants.PASSCODE_NS), passcode);
        usernameToken.getOtherAttributes().put(new QName(AuthnCtxClass.TIME_SYNC_TOKEN_AUTHN_CTX.getValue()), "TRUE");

        Claim claim = new ClaimImpl(AuthnCtxClass.TIME_SYNC_TOKEN_AUTHN_CTX.getValue(), usernameToken);
        ClaimSet claims = new ClaimSetImpl();
        claims.addClaim(claim);

        SamlR2ClaimsResponse claimsResponse = new SamlR2ClaimsResponse (claimsRequest.getId() /* TODO : Generate new ID !*/,
                channel, claimsRequest.getId(), claims, claimsRequest.getRelayState());

        CamelMediationMessage out = (CamelMediationMessage) exchange.getOut();

        out.setMessage(new MediationMessageImpl(claimsResponse.getId(),
                claimsResponse,
                "ClaimsResponse",
                null,
                ed,
                in.getMessage().getState()));

        exchange.setOut(out);

    }
}