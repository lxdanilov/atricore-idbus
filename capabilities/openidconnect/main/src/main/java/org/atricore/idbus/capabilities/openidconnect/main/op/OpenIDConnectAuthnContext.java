package org.atricore.idbus.capabilities.openidconnect.main.op;

import com.nimbusds.oauth2.sdk.AuthorizationCode;
import com.nimbusds.oauth2.sdk.ParseException;
import com.nimbusds.oauth2.sdk.SerializeException;
import com.nimbusds.openid.connect.sdk.AuthenticationRequest;
import org.atricore.idbus.common.sso._1_0.protocol.SPInitiatedAuthnRequestType;
import org.atricore.idbus.common.sso._1_0.protocol.SPInitiatedLogoutRequestType;

import java.io.Serializable;
import java.util.Map;

/**
 *
 */
public class OpenIDConnectAuthnContext implements Serializable {

    // Request sent to SSO endpoint
    private SPInitiatedAuthnRequestType ssoAuthnRequest;

    // Request sent to SLO endponit
    private SPInitiatedLogoutRequestType sloRequest;

    // Non-serializable version
    private transient AuthenticationRequest authnRequest;

    private Map<String, String> authnRequestAsParams;

    // Current emitted Authorization code
    private AuthorizationCode authorizationCode;

    private long authorizationCodeNotOnOrAfter;

    // Selected IDP Alias
    private String idpAlias;

    public String getIdpAlias() {
        return idpAlias;
    }

    public void setIdpAlias(String idpAlias) {
        this.idpAlias = idpAlias;
    }

    public SPInitiatedAuthnRequestType getSsoAuthnRequest() {
        return ssoAuthnRequest;
    }

    public void setSsoAuthnRequest(SPInitiatedAuthnRequestType ssoAuthnRequest) {
        this.ssoAuthnRequest = ssoAuthnRequest;
    }

    public void setSloRequest(SPInitiatedLogoutRequestType request) {
        this.sloRequest = request;
    }

    public SPInitiatedLogoutRequestType getSloRequest() {
        return sloRequest;
    }

    public AuthorizationCode getAuthorizationCode() {
        return authorizationCode;
    }

    public void setAuthorizationCode(AuthorizationCode authorizationCode) {
        this.authorizationCode = authorizationCode;
    }

    public long getAuthorizationCodeNotOnOrAfter() {
        return authorizationCodeNotOnOrAfter;
    }

    public void setAuthorizationCodeNotOnOrAfter(long authorizationCodeNotOnOrAfter) {
        this.authorizationCodeNotOnOrAfter = authorizationCodeNotOnOrAfter;
    }

    public AuthenticationRequest getAuthnRequest() {

        if (authnRequest == null && authnRequestAsParams != null) {
            try {
                authnRequest = AuthenticationRequest.parse(authnRequestAsParams);
            } catch (ParseException e) {
                throw new RuntimeException(e);
            }
        }

        return authnRequest;
    }

    public void setAuthnRequest(AuthenticationRequest authnRequest) {
        this.authnRequest = authnRequest;

        if (authnRequest != null) {
            try {
                this.authnRequestAsParams = authnRequest.toParameters();
            } catch (SerializeException e) {
                throw new RuntimeException(e);
            }
        } else {
            this.authnRequestAsParams = null;
        }
    }
}
