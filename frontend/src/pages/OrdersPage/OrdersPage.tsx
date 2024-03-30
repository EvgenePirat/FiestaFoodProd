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
      <section className={styles['section']}>
        <p className={styles['title']}>Нові замовлення</p>
        <div className={styles['orders-list']}>
          {ordersTodo.map((order) => (
            <OrderCard key={order.id} {...order} />
          ))}
        </div>
      </section>
      <section className={styles['section']}>
        <p className={styles['title']}>Готуються</p>
        <div className={styles['orders-list']}>
          {ordersProgress.map((order) => (
            <OrderCard key={order.id} {...order} />
          ))}
        </div>
      </section>
    </div>
  );
}
