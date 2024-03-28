import { useCallback, useMemo, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { createOrder } from '../../../../redux/ordersSlice';
import { OrderItem, PopupSubmitClear } from '../';

import styles from './AsideBar.module.scss';

export default function AsideBar() {
  const products = useSelector((state: RootState) => state.productsSlice.products);
  const order = useSelector((state: RootState) => state.ordersSlice.order);
  const dispatch = useDispatch();

  const [isVisiblePopupClear, setIsVisiblePopupClear] = useState(false);

  const sum = useMemo(
    () =>
      order.reduce((acc, item) => {
        const product = products.find((obj) => obj.id === item.id);
        return acc + (product?.price ?? 0) * item.count;
      }, 0),
    [order, products]
  );

  const handleClear = useCallback(() => {
    setIsVisiblePopupClear(true);
  }, []);

  return (
    <div className={styles['aside-bar']}>
      <div className={styles['control-block']}>
        <button className={styles['clear-btn']} onClick={handleClear}>
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
        <p className={styles['sum']}>
          Загалом: <span className={styles['value']}>{sum.toFixed(2)} грн</span>
        </p>
        <button className={styles['create-btn']} onClick={() => dispatch(createOrder())}>
          Розрахувати
        </button>
      </div>

      {isVisiblePopupClear && <PopupSubmitClear onClose={() => setIsVisiblePopupClear(false)} />}
    </div>
  );
}
