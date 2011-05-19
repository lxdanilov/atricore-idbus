/*
 * Atricore IDBus
 *
 * Copyright (c) 2009, Atricore Inc.
 *
 * This is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation; either version 2.1 of
 * the License, or (at your option) any later version.
 *
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this software; if not, write to the Free
 * Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
 * 02110-1301 USA, or see the FSF site: http://www.fsf.org.
 */

package org.atricore.idbus.capabilities.samlr2.main.emitter.plans.actions;

import oasis.names.tc.saml._2_0.assertion.AssertionType;
import oasis.names.tc.saml._2_0.assertion.AttributeStatementType;
import oasis.names.tc.saml._2_0.assertion.AttributeType;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.atricore.idbus.capabilities.samlr2.support.SAMLR2Constants;
import org.atricore.idbus.capabilities.samlr2.support.core.AttributeNameFormat;
import org.atricore.idbus.capabilities.samlr2.support.profiles.DCEPACAttributeDefinition;
import org.atricore.idbus.capabilities.sts.main.WSTConstants;
import org.atricore.idbus.kernel.main.authn.*;
import org.atricore.idbus.kernel.planning.IdentityArtifact;
import org.jbpm.graph.exe.ExecutionContext;

import javax.security.auth.Subject;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

/**
 * @author <a href="mailto:sgonzalez@atricore.org">Sebastian Gonzalez Oyuela</a>
 * @version $Id: BuildAuthnAssertionStatementsAction.java 1335 2009-06-24 16:34:38Z sgonzalez $
 */
public class BuildAuthnAssertionStatementsAction extends AbstractSAMLR2AssertionAction {

    private static final Log logger = LogFactory.getLog(BuildAuthnAssertionStatementsAction.class);

    @Override
    protected void doExecute(IdentityArtifact in , IdentityArtifact out, ExecutionContext executionContext) {

        logger.debug("starting action");

        AssertionType assertion = (AssertionType) out.getContent();

        // Do we have a SSOUser ?
        Subject s = (Subject) executionContext.getContextInstance().getVariable(WSTConstants.SUBJECT_PROP);
        Set<SSOUser> ssoUsers = s.getPrincipals(SSOUser.class);
        if (ssoUsers == null || ssoUsers.size() != 1)
            throw new RuntimeException("Subject must contain a SSOUser principal");

        SSOUser ssoUser = ssoUsers.iterator().next();
        AttributeType attrPrincipal = new AttributeType();
        attrPrincipal.setName(DCEPACAttributeDefinition.PRINCIPAL.getValue());
        attrPrincipal.setNameFormat(AttributeNameFormat.URI.getValue());
        attrPrincipal.getAttributeValue().add(ssoUser.getName());

        // This will add SSO User properties as attribute statements.
        List<AttributeType> attrProps = new ArrayList<AttributeType>();
        if (ssoUser.getProperties() != null && ssoUser.getProperties().length > 0) {

            // TODO : We could group some properties as multi valued attributes like, privileges!
            for (SSONameValuePair property : ssoUser.getProperties()) {
                AttributeType attrProp = new AttributeType();
                attrProp.setName(SAMLR2Constants.SSOUSER_PROPERTY_NS + ":" + property.getName());
                attrProp.setNameFormat(AttributeNameFormat.URI.getValue());
                attrProp.getAttributeValue().add(property.getValue());

                attrProps.add(attrProp);
            }
        }

        // Groups
        Set<SSORole> ssoRoles = s.getPrincipals(SSORole.class);

        AttributeType attrRole = new AttributeType();
        // TODO : Make SAML Attribute profile configurable
        attrRole.setName(DCEPACAttributeDefinition.GROUPS.getValue());
        attrRole.setNameFormat(AttributeNameFormat.URI.getValue());
        for(SSORole role : ssoRoles)
            attrRole.getAttributeValue().add( role.getName() );

        // SSO Enforced policies
        // TODO : Can we use SAML Authn context information ?!
        List<AttributeType> attrPolicies = new ArrayList<AttributeType>();
        Set<SSOPolicyEnforcement> ssoPolicyEnforcements = s.getPrincipals(SSOPolicyEnforcement.class);
        for (SSOPolicyEnforcement ssoPolicyEnforcement : ssoPolicyEnforcements) {
            AttributeType attrPolicy = new AttributeType();

            if (ssoPolicyEnforcement instanceof SSOPasswordPolicyEnforcement)
                attrPolicy.setName(SAMLR2Constants.SSOPOLICY_ENF_NS + ":password:" + ssoPolicyEnforcement.getName());
            else
                attrPolicy.setName(SAMLR2Constants.SSOPOLICY_ENF_NS + ":enforcement:" + ssoPolicyEnforcement.getName());

            attrPolicy.setNameFormat(AttributeNameFormat.URI.getValue());

            if (ssoPolicyEnforcement.getValues().size() > 0) {
                for (Object v : ssoPolicyEnforcement.getValues())
                    attrPolicy.getAttributeValue().add(v);
            }

            attrPolicies.add(attrPolicy);
        }


        // Create attribute statements
        AttributeStatementType attributeStatement = new AttributeStatementType();
        attributeStatement.getAttributeOrEncryptedAttribute().add(attrRole);
        attributeStatement.getAttributeOrEncryptedAttribute().add(attrPrincipal);

        if (attrProps.size() > 0) {
            for (AttributeType attrProp : attrProps)
                attributeStatement.getAttributeOrEncryptedAttribute().add(attrProp);
        }

        if (attrPolicies.size() > 0)
            for (AttributeType attrPolicy : attrPolicies)
                attributeStatement.getAttributeOrEncryptedAttribute().add(attrPolicy);

        // Assembly all
        assertion.getStatementOrAuthnStatementOrAuthzDecisionStatement().add( attributeStatement );



        logger.debug("ending action");
    }
}
