import axios from 'axios';
import { useState, useEffect } from 'react';

import styles from './Dashboard.module.css';
import Diagram from '../../Fragments/Diagrams/Diagram';
import { AdminService } from '../../../services/super-admin-service';

export default function Dashboard() {
  const [items, setItems] = useState({});

  const cancelTokenSource = axios.CancelToken.source();

  useEffect(() => {
    async function GetDashboard() {
      await AdminService.dashboardIndex(cancelTokenSource.token)
        .then(r => setItems(r))
    }

    GetDashboard();

    return () => {
      cancelTokenSource.cancel();
    }
  }, [])

  return (
    <div className={styles.dashboard}>
      <section className={styles.header} >
        <article><span>Clients</span><span>{items.clients}</span></article>
        <svg width="1" height="126" viewBox="0 0 1 126">
          <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
        </svg>
        <article><span>Revenue</span><span>{items.revenue}</span></article>
        <svg width="1" height="126" viewBox="0 0 1 126">
          <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
        </svg>
        <article><span>Courses</span><span style={{ color: "#296CFB" }}>{items.courses}</span></article>
        <svg width="1" height="126" viewBox="0 0 1 126">
          <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
        </svg>
        <article><span>Coaches</span><span style={{ color: "#16D696" }}>{items.coaches}</span></article>
      </section>
      <Diagram color="#296CFB" title="Number of Clients" curve={numberOfClients} />
      <Diagram color="#16D696" title="Total Revenue" curve={totalRevenue} />

    </div>)
}
const numberOfClients = [{ x: new Date("January 01"), y: 45 },
{ x: new Date("February 01"), y: 15 },
{ x: new Date("March 01"), y: 25 },
{ x: new Date("April 01"), y: 60 },
{ x: new Date("May 01"), y: 30 },
{ x: new Date("June 01"), y: 45 }];

const totalRevenue = [{ x: new Date("January 01"), y: 1000 },
{ x: new Date("February 01"), y: 800 },
{ x: new Date("March 01"), y: 1000 },
{ x: new Date("April 01"), y: 900 },
{ x: new Date("May 01"), y: 1300 },
{ x: new Date("June 01"), y: 1000 }];