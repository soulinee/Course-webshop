import React from 'react'
import {Outlet, Link} from "react-router-dom";



const AdminLayout: React.FC = () => {
   <div className="min-h-screen flex">
    <aside className="w-64 p-4 bg-gray-100 border-r">
        <div className="mb-4 font-bold"> Admin</div>
        <nav>
            <ul>
                <li><Link to="/admin">Dashboard</Link></li>
                <li><Link to="/admin/courses">Manage Courses</Link></li>
                <li><Link to="/admin/users">Manage Users</Link></li>
            </ul>
        </nav>
    </aside>

    <main className="flex-1 p-6">
        <Outlet/>
    </main>
   </div>
}

export default AdminLayout