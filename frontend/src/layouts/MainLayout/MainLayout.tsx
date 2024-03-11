import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Outlet } from 'react-router-dom';
import { RootState } from '../../redux/store';
import { loadProducts, loadTypes } from '../../redux/productsSlice';

import { Header } from '../../components';

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
          <Header />
          <main className={styles['main']}>
            <Outlet />
          </main>
        </div>
      ) : (
        <div className={styles['loader']}>Loading...</div>
      )}
    </>
  );
}
