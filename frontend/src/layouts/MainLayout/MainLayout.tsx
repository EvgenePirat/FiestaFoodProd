import { useDispatch } from 'react-redux';
import {Outlet, useNavigate} from 'react-router-dom';
import { signIn, signOut } from '../../redux/authSlice';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  const dispatch = useDispatch();
  const navigate = useNavigate();

    const handleAuth = () => {
        navigate('/auth');
        dispatch(signIn());
    };

    return (
    <div className={styles['main-block']}>
      <div className={styles['header']} onClick={() => handleAuth()}>
        Header. Click to get true.
      </div>
      <main className={styles['main']}>
        <Outlet />
      </main>
      <div className={styles['footer']} onClick={() => dispatch(signOut())}>
        Footer. Click to get false.
      </div>
    </div>
  );
}
