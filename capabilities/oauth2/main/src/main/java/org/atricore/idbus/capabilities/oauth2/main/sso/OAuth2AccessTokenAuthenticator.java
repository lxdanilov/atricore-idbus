package org.atricore.idbus.capabilities.oauth2.main.sso;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.atricore.idbus.capabilities.sts.main.AbstractSecurityTokenAuthenticator;
import org.atricore.idbus.kernel.main.authn.Credential;
import org.atricore.idbus.kernel.main.authn.exceptions.SSOAuthenticationException;
import org.oasis_open.docs.wss._2004._01.oasis_200401_wss_wssecurity_secext_1_0.PasswordString;

/**
 * @author <a href="mailto:gbrigandi@atricore.org">Gianluca Brigandi</a>
 */
public class OAuth2AccessTokenAuthenticator extends AbstractSecurityTokenAuthenticator {

    private static final Log logger = LogFactory.getLog(OAuth2AccessTokenAuthenticator.class);

    private static final String SCHEME_NAME = "oauth2-authentication";

    public OAuth2AccessTokenAuthenticator() {
        super(SCHEME_NAME);
        setScheme(SCHEME_NAME);
    }

    @Override
    protected Credential[] getCredentials(Object requestToken) throws SSOAuthenticationException {

        PasswordString accessToken = (PasswordString) requestToken;

        String oauth2AccessToken = accessToken.getValue();

        Credential oauth2Credential = getAuthenticator().newCredential(getScheme(), "oauth2AccessToken", oauth2AccessToken);
        return new Credential[] {oauth2Credential};
    }

    public boolean canAuthenticate(Object requestToken) {

        if (logger.isTraceEnabled())
            logger.trace("Token: " + (requestToken != null ? requestToken.getClass().getName() : "null"));

        if (requestToken instanceof PasswordString){
            return true;
        }
        return false;
    }
}
