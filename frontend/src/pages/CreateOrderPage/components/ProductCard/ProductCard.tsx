import { useDispatch } from 'react-redux';
import { addItem } from '../../../../redux/ordersSlice';
import { ProductCardType } from '../../../../types/ProductCardType';

import styles from './ProductCard.module.scss';

interface ProductCardProps {
  item: ProductCardType;
}

export default function ProductCard({ item }: ProductCardProps) {
  const dispatch = useDispatch();

  return (
    <li className={styles['card']} onClick={() => dispatch(addItem(item.id))}>
      <div className={styles['image-block']}>
        <img className={styles['image']} src={item.image} alt={item.title} />
      </div>
      <p className={styles['title']}>{item.title}</p>
    </li>
  );
}
