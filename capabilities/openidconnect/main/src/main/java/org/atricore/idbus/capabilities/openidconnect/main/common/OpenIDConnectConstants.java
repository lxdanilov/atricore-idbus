package org.atricore.idbus.capabilities.openidconnect.main.common;

import javax.xml.namespace.QName;

/**
 * Created by sgonzalez on 3/11/14.
 */
public interface OpenIDConnectConstants {

    final static QName AuthzTokenConsumerService_QNAME = new QName("urn:org:atricore:idbus:openidconnect:metadata", "AuthzTokenConsumerService");

    final static QName AuthzCodeProviderService_QNAME = new QName("urn:org:atricore:idbus:openidconnect:metadata", "AuthzCodeProviderService");
}
