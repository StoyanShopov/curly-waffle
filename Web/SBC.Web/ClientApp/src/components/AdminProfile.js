import NavigationBar from "./super-admin/NavigationBar";
import Dashboard from './super-admin/Dashboard';
import css from './AdminProfile.module.css'

export default function AdminProfile(){
    

    return (
        <div className={css.mainContent}>
            <NavigationBar/>
            <Dashboard/>
        </div>
    )
}