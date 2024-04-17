import { useCallback, useMemo } from 'react';
import { useDispatch } from 'react-redux';
import { changeOrderStatus } from '../../../../redux/ordersSlice';

import { OrderState } from '../../../../types/enums';
import { OrderType } from '../../../../types/OrderType';

import { Button } from '../../../../components';
import DishItem from '../DishItem/DishItem';

import styles from './OrderCard.module.scss';

interface OrderCardProps {
  id: OrderType['id'];
  orderCreateDate: OrderType['orderCreateDate'];
  orderItems: OrderType['orderItems'];
  orderState: OrderType['orderState'];
}

export default function OrderCard({ id, orderCreateDate, orderItems, orderState }: OrderCardProps) {
  const dispatch = useDispatch();

  const time = useMemo(() => {
    const dateObj = new Date(orderCreateDate);
    return `${dateObj.getHours()}:${dateObj.getMinutes()}`;
  }, [orderCreateDate]);

  const startOrder = useCallback(() => {
    dispatch(changeOrderStatus({ id, value: OrderState.progress }));
  }, [dispatch, id]);

  const completeOrder = useCallback(() => {
    dispatch(changeOrderStatus({ id, value: OrderState.complete }));
  }, [dispatch, id]);

  return (
    <div className={styles['order-card']}>
      <div className={styles['head']}>
        <h3 className={styles['id']}>{id}</h3>
        <p className={styles['time']}>{time}</p>
      </div>
      <div className={styles['list']}>
        {orderItems.map((item) => (
          <DishItem key={item.dishId} {...item} />
        ))}
      </div>
      {orderState === OrderState.todo ? (
        <Button btnStyle="danger" onClick={startOrder}>
          Готувати
        </Button>
      ) : (
        <Button btnStyle="success" onClick={completeOrder}>
          Готове
        </Button>
      )}
    </div>
  );
}
