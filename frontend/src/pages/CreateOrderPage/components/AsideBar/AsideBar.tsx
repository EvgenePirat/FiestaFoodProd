import styles from './AsideBar.module.scss';

export default function AsideBar() {
  return (
    <div className={styles['aside-bar']}>
      <div className={styles['control-block']}>
        <div className={styles['btn']}>Clear</div>
      </div>

      <div className={styles['table-block']}>
        <div className={styles['head']}>
          <span>Title</span>
          <span>Count</span>
          <span>Price</span>
          <span>Final price</span>
        </div>
        <ul className={styles['list']}>
          <li className={styles['item']}>
            <span>Title</span>
            <span>Count</span>
            <span>Price</span>
            <span>Final price</span>
          </li>
          <li className={styles['item']}>
            <span>Title</span>
            <span>Count</span>
            <span>Price</span>
            <span>Final price</span>
          </li>
        </ul>
      </div>

      <div className={styles['conclusive']}>
        <div className={styles['info-block']}>
          <div className={styles['info']}>
            <p className={styles['sum']}>
              Загалом: <span className={styles['value']}>570 грн</span>
            </p>
            <p className={styles['discount']}>Знижка: 10%</p>
          </div>
          <p className={styles['final-sum']}>513 грн</p>
        </div>
        <div className={styles['btn-block']}>Розрахувати</div>
      </div>
    </div>
  );
}
