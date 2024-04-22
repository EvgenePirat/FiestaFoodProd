import { useMemo } from 'react';
import { OrderItemType } from '../../../../types/OrderItemType';

import styles from './DishItem.module.scss';
import { useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';

interface DishItemProps {
  dishId: OrderItemType['dishId'];
  count: OrderItemType['count'];
  comment: OrderItemType['comment'];
}

export default function DishItem({ dishId, count, comment }: DishItemProps) {
  const dishes = useSelector((state: RootState) => state.productsSlice.dishes);

  const dish = useMemo(() => dishes.find((obj) => obj.id === dishId), [dishes, dishId]);

  return (
    <div className={styles['dish']}>
      {dish ? (
        <>
          <div className={styles['title-block']}>
            <p className={styles['title']}>{dish.title}</p>
            {!!comment.length && <p className={styles['comment']}>{comment}</p>}
          </div>
          <p className={styles['count']}>{count}</p>
        </>
      ) : (
        <p className={styles['not-found']}>Not found dish</p>
      )}
    </div>
  );
}
