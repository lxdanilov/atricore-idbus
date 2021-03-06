/*
 * Atricore IDBus
 *
 *   Copyright 2009, Atricore Inc.
 *
 *   This is free software; you can redistribute it and/or modify it
 *   under the terms of the GNU Lesser General Public License as
 *   published by the Free Software Foundation; either version 2.1 of
 *   the License, or (at your option) any later version.
 *
 *   This software is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 *   Lesser General Public License for more details.
 *
 *   You should have received a copy of the GNU Lesser General Public
 *   License along with this software; if not, write to the Free
 *   Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
 *   02110-1301 USA, or see the FSF site: http://www.fsf.org.
 */

package org.atricore.idbus.kernel.main.provisioning.exception;

/**
 * User: cdbirge
 * Date: Oct 2, 2009
 * Time: 3:22:23 PM
 * email: cbirge@atricore.org
 */
public class UserNotFoundException extends ProvisioningException {

    public UserNotFoundException(long userId, String username) {
        super("The user with id "+userId+" username '" + username+ "' couldn't be found");
    }


    public UserNotFoundException(long userId) {
        super("The user with id "+userId+" couldn't be found");
    }

    public UserNotFoundException(String userName) {
        super("The user with userName "+userName+" couldn't be found");
    }

}
