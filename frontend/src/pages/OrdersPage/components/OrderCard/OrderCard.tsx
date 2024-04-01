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
  date: OrderType['date'];
  list: OrderType['list'];
  status: OrderType['status'];
}

export default function OrderCard({ id, date, list, status }: OrderCardProps) {
  const dispatch = useDispatch();

  const time = useMemo(() => {
    const dateObj = new Date(date);
    return `${dateObj.getHours()}:${dateObj.getMinutes()}`;
  }, [date]);

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
        {list.map((item) => (
          <DishItem key={item.id} {...item} />
        ))}
      </div>
      {status === OrderState.todo ? (
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
