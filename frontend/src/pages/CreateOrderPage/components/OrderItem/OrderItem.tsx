import { useMemo, useState } from 'react';
import { products } from '../../../../data/fakeProducts';

import styles from './OrderItem.module.scss';

interface OrderItemProps {
  id: number;
  count: number;
}

export default function OrderItem({ id, count }: OrderItemProps) {
  const [isOpen, setIsOpen] = useState(false);
  const [value, setValue] = useState('');

  const product = useMemo(() => {
    return products.find((obj) => obj.id === id);
  }, [id]);

  return (
    <li className={styles['item']} onClick={() => setIsOpen(true)}>
      {product ? (
        <>
          <div className={styles['info-content']}>
            <span>{product.title}</span>
            <span>{count}</span>
            <span>{product.price}</span>
            <span>{count * product.price}</span>
          </div>
          {isOpen && (
            <div className={styles['comment-block']}>
              <p>Коментар: </p>
              <input
                className={styles['input']}
                value={value}
                onChange={(e) => setValue(e.target.value)}
                type="text"
              />
            </div>
          )}
        </>
      ) : (
        <p className={styles['not-found']}>Not Found {id}</p>
      )}
    </li>
  );
}
