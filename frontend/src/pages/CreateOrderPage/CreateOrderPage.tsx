import { AsideBar, ProductCard } from './components';
import { products } from '../../data/fakeProducts';

import styles from './CreateOrderPage.module.scss';

export default function CreateOrderPage() {
  return (
    <div className={styles['page-block']}>
      <AsideBar />
      <div className={styles['list-block']}>
        <p className={styles['p-title']}>All products</p>
        <ul className={styles['list']}>
          {products.map((product) => (
            <ProductCard key={product.id} item={product} />
          ))}
        </ul>
      </div>
    </div>
  );
}
