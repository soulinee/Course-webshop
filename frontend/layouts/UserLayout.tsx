import React from "react";
import {Outlet, Link} from "react-router-dom";

 

const UserLayout: React.FC = () => {
   <>
   <div className="min-h-screen flex">
    <aside className="w-64 p-4 border-r">
        <nav>
            <ul>
                <li> <Link to="/dashboard"> Dashboard</Link></li>
                <li> <Link to="/courses"> Dashboard</Link></li>
                <li> <Link to="/profile"> Dashboard</Link></li>
            </ul>
        </nav>
    </aside>
    <main className="flex-1 p-6">
        <Outlet/>
    </main>

   </div>
   
   </>
}

export default UserLayout