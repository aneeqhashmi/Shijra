import React from 'react';
import { withAuthorization } from '../Session';
import * as ROLES from '../../constants/roles';

const AdminPage = () => (
    <div>
        <h1>Admin</h1>
        <p>
            Restricted area! Only users with the admin role are authorized.
    </p>
    </div>
);

const condition = authUser =>
    authUser && ROLES.ADMIN_LIST.indexOf(authUser.email) >= 0;

export default withAuthorization(condition)(AdminPage);