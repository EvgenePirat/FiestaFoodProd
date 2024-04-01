import { useMemo } from 'react';
import { OrderItemType } from '../../../../types/OrderItemType';

import styles from './DishItem.module.scss';
import { useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';

interface DishItemProps {
  id: OrderItemType['id'];
  count: OrderItemType['count'];
  comment: OrderItemType['comment'];
}

export default function DishItem({ id, count, comment }: DishItemProps) {
  const dishes = useSelector((state: RootState) => state.productsSlice.products);

  const dish = useMemo(() => dishes.find((obj) => obj.id === id), [dishes, id]);

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
