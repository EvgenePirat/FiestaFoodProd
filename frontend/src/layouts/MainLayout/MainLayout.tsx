import { useDispatch } from 'react-redux';
import { Outlet } from 'react-router-dom';
import { signOut } from '../../redux/authSlice';

import { Header } from '../../components';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  const dispatch = useDispatch();

  return (
    <div className={styles['main-block']}>
      <Header />
      <main className={styles['main']}>
        <Outlet />
      </main>
      <div className={styles['footer']} onClick={() => dispatch(signOut())}>
        Footer. Click to get false.
      </div>
    </div>
  );
}
