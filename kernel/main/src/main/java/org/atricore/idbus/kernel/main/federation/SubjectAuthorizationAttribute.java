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

package org.atricore.idbus.kernel.main.federation;

import java.io.Serializable;
import java.security.Principal;

/**
 *
 * @author <a href="mailto:gbrigand@josso.org">Gianluca Brigandi</a>
 * @version $Rev: 1040 $ $Date: 2009-03-04 22:56:52 -0200 (Wed, 04 Mar 2009) $
 */
public class SubjectAuthorizationAttribute implements Principal, Serializable {

    public static enum Name {
        ACTION_NAMESPACE,
        ACTION_VALUE,
        DECISION,
        RESOURCE
    }

    private Name name;
    private String value;

    public SubjectAuthorizationAttribute(Name name, String value) {
        this.name = name;
        this.value = value;

    }

    public String getName() {
        return name.name();
    }

    public String getValue() {
        return value;
    }

    public String toString() {
        return "[Subject Authorization Attribute: " + name + "=" + value + "]";
    }


}
