import { useEffect } from 'react';
import { Outlet } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../../redux/store';
import { loadDishes, loadCategories } from '../../redux/dishesSlice.ts';
import { loadOrders } from '../../redux/ordersSlice';

import { Header } from '../../components';

import styles from './MainLayout.module.scss';

export default function MainLayout() {
  const categories = useSelector((state: RootState) => state.productsSlice.categories);
  const dishes = useSelector((state: RootState) => state.productsSlice.dishes);
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    (async () => {
      await dispatch(loadCategories());
      await dispatch(loadDishes());
    })();
    dispatch(loadOrders());
  }, [dispatch]);

  return (
    <>
      {categories.length && dishes.length ? (
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
