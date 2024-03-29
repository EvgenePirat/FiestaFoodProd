import styles from './OrdersPage.module.scss';

export default function OrdersPage() {
  return (
    <div className={styles['page-block']}>
      <section className={styles['section']}>
        <p className={styles['title']}>Нові замовлення</p>
        <div className={styles['orders-list']}>
          <div className={styles['order']}>51</div>
        </div>
      </section>
      <section className={styles['section']}>
        <p className={styles['title']}>Готуються</p>
        <div className={styles['orders-list']}>
          <div className={styles['order']}>51</div>
        </div>
      </section>
    </div>
  );
}
