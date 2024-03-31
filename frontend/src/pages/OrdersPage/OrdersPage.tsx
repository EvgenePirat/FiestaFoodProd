import { useMemo } from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../redux/store';

import { OrderState } from '../../types/enums';

import { OrderCard } from './components';

import styles from './OrdersPage.module.scss';

export default function OrdersPage() {
  const orders = useSelector((state: RootState) => state.ordersSlice.orders);

  const ordersTodo = useMemo(
    () => orders.filter((order) => order.status === OrderState.todo),
    [orders]
  );
  const ordersProgress = useMemo(
    () => orders.filter((order) => order.status === OrderState.progress),
    [orders]
  );

  return (
    <div className={styles['page-block']}>
      <section className={`${styles['section']} ${styles['todo']}`}>
        <p className={styles['title']}>Нові замовлення</p>
        <div className={styles['orders-block']}>
          {ordersTodo.length ? (
            ordersTodo.map((order) => <OrderCard key={order.id} {...order} />)
          ) : (
            <p className={styles['empty-message']}>Нових замовлень немає</p>
          )}
        </div>
      </section>
      <section className={`${styles['section']} ${styles['progress']}`}>
        <p className={styles['title']}>Готуються</p>
        <div className={styles['orders-block']}>
          {ordersProgress.length ? (
            ordersProgress.map((order) => <OrderCard key={order.id} {...order} />)
          ) : (
            <p className={styles['empty-message']}>Зараз нічого не готується</p>
          )}
        </div>
      </section>
    </div>
  );
}
