import { ProductCard } from '../';
import { products } from '../../../../data/fakeProducts';

import styles from './ProductCardList.module.scss';

export default function ProductCardList() {
  return (
    <div className={styles['list-block']}>
      <div className={styles['control-block']}>
        <p className={styles['mark']}>Усі товари</p>
      </div>
      <ul className={styles['list']}>
        {products.map((product) => (
          <ProductCard key={product.id} item={product} />
        ))}
      </ul>
    </div>
  );
}
