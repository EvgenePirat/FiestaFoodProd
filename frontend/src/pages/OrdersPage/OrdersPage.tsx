import { useSelector } from 'react-redux';
import { RootState } from '../../redux/store';

import { OrderCard } from './components';

import styles from './OrdersPage.module.scss';

export default function OrdersPage() {
  const orders = useSelector((state: RootState) => state.ordersSlice.orders);

  return (
    <div className={styles['page-block']}>
      <section className={styles['section']}>
        <p className={styles['title']}>Нові замовлення</p>
        <div className={styles['orders-list']}>
          {orders.map((order) => (
            <OrderCard key={order.id} {...order} />
          ))}
        </div>
      </section>
      <section className={styles['section']}>
        <p className={styles['title']}>Готуються</p>
        <div className={styles['orders-list']}>
          {orders.map((order) => (
            <OrderCard key={order.id} {...order} />
          ))}
        </div>
      </section>
    </div>
  );
}
