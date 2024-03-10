import { useEffect, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { clearOrder, createOrder } from '../../../../redux/ordersSlice';
import { OrderItem } from '../';

import { products } from '../../../../data/fakeProducts';

import styles from './AsideBar.module.scss';

const discount = 10;

export default function AsideBar() {
  const order = useSelector((state: RootState) => state.ordersSlice.order);
  const dispatch = useDispatch();

  const sum = useMemo(
    () =>
      order.reduce((acc, item) => {
        const product = products.find((obj) => obj.id === item.id);
        return acc + (product?.price ?? 0) * item.count;
      }, 0),
    [order]
  );

  useEffect(() => console.log(order), [order]);

  const finalSum = useMemo(() => (sum * (100 - discount)) / 100, [sum]);

  return (
    <div className={styles['aside-bar']}>
      <div className={styles['control-block']}>
        <button className={styles['clear-btn']} onClick={() => dispatch(clearOrder())}>
          Очистити
        </button>
      </div>

      <div className={styles['table-block']}>
        <div className={styles['head']}>
          <span>Найменування</span>
          <span>К-ть</span>
          <span>Ціна</span>
          <span>Загалом</span>
        </div>
        {order.length ? (
          <ul className={styles['list']}>
            {order.map((obj) => (
              <OrderItem key={obj.id} item={obj} />
            ))}
          </ul>
        ) : (
          <div className={styles['empty']}>List is empty</div>
        )}
      </div>

      <div className={styles['conclusive']}>
        <div className={styles['info-block']}>
          <div className={styles['info']}>
            <p className={styles['sum']}>
              Загалом: <span className={styles['value']}>{sum}</span>
            </p>
            <p className={styles['discount']}>Знижка: {discount}%</p>
          </div>
          <p className={styles['final-sum']}>{finalSum} грн</p>
        </div>
        <button className={styles['create-btn']} onClick={() => dispatch(createOrder())}>
          Розрахувати
        </button>
      </div>
    </div>
  );
}
