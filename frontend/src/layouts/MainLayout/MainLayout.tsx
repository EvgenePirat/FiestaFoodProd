import { Outlet } from 'react-router-dom';

import { Header } from '../../components';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  return (
    <div className={styles['main-block']}>
      <Header />
      <main className={styles['main']}>
        <Outlet />
      </main>
    </div>
  );
}
