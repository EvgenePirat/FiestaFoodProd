import { ProductCardType } from '../../../../types/ProductCardType';

import styles from './ProductCard.module.scss';

interface ProductCardProps {
  item: ProductCardType;
}

export default function ProductCard({ item }: ProductCardProps) {
  const onClickHandler = () => console.log(item.id);

  return (
    <li className={styles['card']} onClick={onClickHandler}>
      <div className={styles['image-block']}>
        <img className={styles['image']} src={item.image} alt={item.title} />
      </div>
      <p className={styles['title']}>{item.title}</p>
    </li>
  );
}
