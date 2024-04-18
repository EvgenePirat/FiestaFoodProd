import { useCallback, useMemo, useState } from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';

import { Button } from '../../../../components';
import { OrderItem, PopupCreateOrder, PopupSubmitClear } from '../';

import styles from './AsideBar.module.scss';

export default function AsideBar() {
  const dishes = useSelector((state: RootState) => state.productsSlice.dishes);
  const orderItems = useSelector((state: RootState) => state.ordersSlice.orderItems);

  const [isVisiblePopupClear, setIsVisiblePopupClear] = useState(false);
  const [isVisiblePopupCreate, setIsVisiblePopupCreate] = useState(false);

  const sum = useMemo(
    () =>
      orderItems.reduce((acc, item) => {
        const dish = dishes.find((obj) => obj.id === item.dishId);
        return acc + (dish?.price ?? 0) * item.count;
      }, 0),
    [orderItems, dishes]
  );

  const handleClear = useCallback(() => {
    setIsVisiblePopupClear(true);
  }, []);

  const handleCreate = useCallback(() => {
    setIsVisiblePopupCreate(true);
  }, []);

  return (
    <div className={styles['aside-bar']}>
      <div className={styles['control-block']}>
        <p className={styles['book-mark']}>Створення замовлення</p>
        <button className={styles['book-mark']} onClick={handleClear}>
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
        {orderItems.length ? (
          <ul className={styles['list']}>
            {orderItems.map((obj) => (
              <OrderItem key={obj.dishId} item={obj} />
            ))}
          </ul>
        ) : (
          <div className={styles['empty']}>Замовлення порожнє</div>
        )}
      </div>

      <div className={styles['conclusive']}>
        <p className={styles['sum']}>
          Загалом: <span className={styles['value']}>{sum.toFixed(2)} грн</span>
        </p>
        <Button
          btnStyle="success"
          className={styles['create-btn']}
          onClick={handleCreate}
          disabled={!orderItems.length}>
          Розрахувати
        </Button>
      </div>

      {isVisiblePopupClear && <PopupSubmitClear onClose={() => setIsVisiblePopupClear(false)} />}
      {isVisiblePopupCreate && <PopupCreateOrder onClose={() => setIsVisiblePopupCreate(false)} />}
    </div>
  );
}
