import { AsideBar, ProductCardList } from './components';

import styles from './CreateOrderPage.module.scss';

export default function CreateOrderPage() {
  return (
    <div className={styles['page-block']}>
      <AsideBar />
      <ProductCardList />
    </div>
  );
}
