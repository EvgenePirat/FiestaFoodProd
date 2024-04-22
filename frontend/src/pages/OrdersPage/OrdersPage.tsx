import { useMemo } from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../redux/store';

import { OrderState } from '../../types/enums';

import { OrderCard } from './components';

import styles from './OrdersPage.module.scss';

export default function OrdersPage() {
  const orders = useSelector((state: RootState) => state.ordersSlice.orders);

  const ordersTodo = useMemo(
    () => orders.filter((order) => order.orderState === OrderState.todo),
    [orders]
  );
  const ordersProgress = useMemo(
    () => orders.filter((order) => order.orderState === OrderState.progress),
    [orders]
  );

  return (
    <div className={styles['page-block']}>
      <section className={`${styles['section-orders']} ${styles['todo']}`}>
        {ordersTodo.length ? (
          <>
            <p className={styles['title']}>Нові замовлення</p>
            <div className={styles['list']}>
              {ordersTodo.map((order) => (
                <OrderCard key={order.id} {...order} />
              ))}
            </div>
          </>
        ) : (
          <p className={styles['empty-message']}>Нових замовлень немає</p>
        )}
      </section>
      <hr className={styles['hr']} />
      <section className={`${styles['section-orders']} ${styles['progress']}`}>
        {ordersProgress.length ? (
          <>
            <p className={styles['title']}>Готуються</p>
            <div className={styles['list']}>
              {ordersProgress.map((order) => (
                <OrderCard key={order.id} {...order} />
              ))}
            </div>
          </>
        ) : (
          <p className={styles['empty-message']}>Зараз нічого не готується</p>
        )}
      </section>
    </div>
  );
}
