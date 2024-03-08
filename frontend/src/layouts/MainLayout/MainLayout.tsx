import { useDispatch } from 'react-redux';
import { Outlet } from 'react-router-dom';
import { signOut } from '../../redux/authSlice';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  const dispatch = useDispatch();

  return (
    <div className={styles['main-block']}>
      <div className={styles['header']}>Header. Click to get true.</div>
      <main className={styles['main']}>
        <Outlet />
      </main>
      <div className={styles['footer']} onClick={() => dispatch(signOut())}>
        Footer. Click to get false.
      </div>
    </div>
  );
}
