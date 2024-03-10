import { useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { ProductCard } from '../';

import styles from './ProductCardList.module.scss';

export default function ProductCardList() {
  const products = useSelector((state: RootState) => state.productsSlice.products);

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
