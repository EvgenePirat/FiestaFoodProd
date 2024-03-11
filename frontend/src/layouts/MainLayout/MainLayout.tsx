import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Outlet } from 'react-router-dom';
import { RootState } from '../../redux/store';
import { signOut } from '../../redux/authSlice';
import { loadProducts, loadTypes } from '../../redux/productsSlice';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  const types = useSelector((state: RootState) => state.productsSlice.types);
  const products = useSelector((state: RootState) => state.productsSlice.products);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(loadTypes());
    dispatch(loadProducts());
  }, [dispatch]);

  return (
    <>
      {types.length && products.length ? (
        <div className={styles['main-block']}>
          <div className={styles['header']}>Header. Click to get true.</div>
          <main className={styles['main']}>
            <Outlet />
          </main>
          <div className={styles['footer']} onClick={() => dispatch(signOut())}>
            Footer. Click to get false.
          </div>
        </div>
      ) : (
        <div className={styles['loader']}>Loading...</div>
      )}
    </>
  );
}
