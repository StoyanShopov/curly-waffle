import NavigationBar from "./super-admin/NavigationBar";
import Dashboard  from './super-admin/Dashboard';
import Revenue  from './super-admin/Revenue';
import Clients  from './super-admin/Clinets';
import css from './AdminProfile.module.css'

export default function AdminProfile(props) {

    let view = props.nav == "clients"
        ? <Clients />
        : props.nav == "revenue"
            ? <Revenue />
            : <Dashboard />;

    return (
        <div className={css.mainContent}>
            <NavigationBar />
            {view}
        </div>
    )
}