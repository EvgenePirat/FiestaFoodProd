import { useMemo } from 'react';
import { OrderType } from '../../../../types/OrderType';

import { Button } from '../../../../components';
import DishItem from '../DishItem/DishItem';

import styles from './OrderCard.module.scss';

interface OrderCardProps {
  id: OrderType['id'];
  date: OrderType['date'];
  list: OrderType['list'];
}

export default function OrderCard({ id, date, list }: OrderCardProps) {
  const time = useMemo(() => {
    const dateObj = new Date(date);
    return `${dateObj.getHours()}:${dateObj.getMinutes()}`;
  }, [date]);

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
      <Button btnStyle="danger">Ujnedfnb</Button>
    </div>
  );
}
