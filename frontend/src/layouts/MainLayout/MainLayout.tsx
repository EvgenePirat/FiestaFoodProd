import { Outlet } from 'react-router-dom';

import styles from './MainLayout.module.scss';

type MainLayoutProps = {
  setIsAuth: (value: boolean) => void;
};

export default function MainLayout({ setIsAuth }: MainLayoutProps) {
  return (
    <div className={styles['main-block']}>
      <div className={styles['header']} onClick={() => setIsAuth(true)}>
        Header. Click to get true.
      </div>
      <main className={styles['main']}>
        <Outlet />
      </main>
      <div className={styles['footer']} onClick={() => setIsAuth(false)}>
        Footer. Click to get false.
      </div>
    </div>
  );
}
