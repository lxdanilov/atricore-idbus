package org.atricore.idbus.capabilities.openidconnect.main.op;

import org.apache.camel.Endpoint;
import org.apache.camel.impl.DefaultComponent;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.atricore.idbus.capabilities.openidconnect.main.common.OpenIDConnectService;
import org.atricore.idbus.capabilities.openidconnect.main.op.endpoints.*;
import org.atricore.idbus.kernel.main.mediation.camel.AbstractCamelEndpoint;

import java.util.Map;

/**
 *
 */
public class OpenIDConnectComponent extends DefaultComponent {

    private static final Log logger = LogFactory.getLog(OpenIDConnectComponent.class);

    public OpenIDConnectComponent() {
    }

    @Override
    protected Endpoint createEndpoint(String uri, String remaining, Map parameters) throws Exception {

        logger.debug("Creating Camel Endpoint for [" + uri + "] [" + remaining + "]");

        AbstractCamelEndpoint endpoint;
        OpenIDConnectService e = getOpenIDService( remaining );

        switch ( e ) {
            case AuthorizationService:
                endpoint = new AuthorizationEndpoint(uri, this, parameters);
                break;

            case TokenService:
                endpoint = new TokenEndpoint(uri, this, parameters);
                break;

            case SSOAssertionConsumerService:
                endpoint = new AssertionConsumerEndpoint(uri, this, parameters);
                break;

            case SSOSingleLogoutService:
                endpoint = new SSOSingleLogoutEndpoint(uri, this, parameters);
                break;

            case SSOSingleSignOnService:
                endpoint = new SSOSingleSignOnEndpoint(uri, this, parameters);
                break;


            default:
                throw new IllegalArgumentException( "Unsupported OpenID Connect endpoint " + remaining );
        }

        endpoint.setAction( remaining );
        setProperties( endpoint, parameters );

        return endpoint;

    }

    protected OpenIDConnectService getOpenIDService(String remaining) {

        for (OpenIDConnectService et : OpenIDConnectService.values()) {
            if (et.getQname().getLocalPart().equals(remaining))
                return et;
        }
        throw new IllegalArgumentException( "Invalid OpenID connect endpoint specified for endpoint " + remaining );
    }
}
