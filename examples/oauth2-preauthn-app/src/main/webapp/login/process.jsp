<%@ page import="org.atricore.idbus.capabilities.oauth2.client.OAuth2Client" %>
<%@ page import="org.atricore.idbus.capabilities.oauth2.client.OAuth2ClientException" %>
<%@ page import="org.atricore.idbus.capabilities.oauth2.common.OAuth2AccessToken" %>
<%@ page import="org.atricore.idbus.capabilities.oauth2.rserver.AccessTokenResolver" %>
<%@ page import="org.atricore.idbus.capabilities.oauth2.rserver.AccessTokenResolverFactory" %>
<%@ page import="org.atricore.idbus.common.oauth._2_0.protocol.SSOPolicyEnforcementStatementType" %>
<%@ page import="java.util.List" %>
<%

    // Create oauth 2 client using properties file and initialize it
    // (This can be configured as part of the app. initialization.
    OAuth2Client client = new OAuth2Client("/oauth2.properties");
    client.init();

    // Create access token resolver instace
    AccessTokenResolver tokenResolver = AccessTokenResolverFactory.newInstance("/oauth2.properties").newResolver();

    // Request the pre-authentication URL for the received credentials
    Throwable error = null;

    try {

        String relayState = (String) session.getAttribute("relay_state");

        // This requests a token from the JOSSO server using the configured SOAP response endpoint


        // Resolve the token to get user details

        if (relayState != null) {
            String accessToken = client.requestToken(request.getParameter("username"), request.getParameter("password"));

            // Build the idpUrl based on the received token
            OAuth2AccessToken at = tokenResolver.resolve(accessToken);
            String userId = at.getUserId();
            String email = at.getAttribute("email");

            String idpUrl = client.buildIdPPreAuthnResponseUrl(relayState, accessToken);

            boolean rememberMe = Boolean.parseBoolean(request.getParameter("rememberMe"));
            if (rememberMe)
                idpUrl = idpUrl + "&remember_me=true";


            session.removeAttribute("relay_state");

            // Redirect the user to the received URL
            response.sendRedirect(idpUrl);
        } else {
            String defaultSPAlias = "https://josso.atricore.com/IDBUS/IDA-1/SP-APP-1/SAML2/MD";
            String idpUrl = client.buildIdPInitPreAuthnUrl(defaultSPAlias, request.getParameter("username"), request.getParameter("password"));

            boolean rememberMe = Boolean.parseBoolean(request.getParameter("rememberMe"));
            if (rememberMe)
                idpUrl = idpUrl + "&remember_me=true";

            // Redirect the user to the received URL
            response.sendRedirect(idpUrl);
        }

        return;
    } catch (OAuth2ClientException e) {
        error = e;
    }

%>
<html>
<head>
    <title>Login Error</title>
</head>
<body>

<h2>Invalid user name or password.</h2>

<p>
    Please enter a user name or password that is authorized to access this
    application.Click here to <a href="<%=request.getContextPath()%>/login/form.jsp">Try Again</a>
</p>
<p>
    Error Details:

    <%
        List<SSOPolicyEnforcementStatementType> ssoPolicyEnforcements = ((OAuth2ClientException) error).getSsoPolicyEnforcements();
        if (ssoPolicyEnforcements != null && ssoPolicyEnforcements.size() > 0) {%>
            <br/><br/>Policy Enforcements:<br/><br/>
            <%for (SSOPolicyEnforcementStatementType stmt : ssoPolicyEnforcements) {%>
                <%=stmt.getName()%>
                <br/><br/>
            <%}
        }
    %>

    <% // Look for the root cause of the problem
        Throwable cause = error.getCause();
        while (cause != null) {
            error = cause;
            cause = error.getCause();
        }
        error.printStackTrace();
    %>

    <%=error.getMessage()%>

</p>
</body>
</html>

