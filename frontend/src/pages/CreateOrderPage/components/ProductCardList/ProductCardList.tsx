import { useMemo } from 'react';
import { NavLink, useNavigate, useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { addItem } from '../../../../redux/ordersSlice';
import { ProductCard } from '../';
import { routeCreateOrder } from '../../../../data/routes';

import styles from './ProductCardList.module.scss';

export default function ProductCardList() {
  const types = useSelector((state: RootState) => state.productsSlice.types);
  const products = useSelector((state: RootState) => state.productsSlice.products);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { type: typeValue } = useParams();

  const type = useMemo(() => types.find((obj) => obj.id === typeValue), [typeValue, types]);

  const displayProducts = useMemo(() => {
    if (!typeValue) return [];
    return products.filter((obj) => obj.type === typeValue);
  }, [products, typeValue]);

  return (
    <div className={styles['list-block']}>
      <div className={styles['control-block']}>
        {typeValue && (
          <NavLink to={`/${routeCreateOrder}`} className={styles['mark']}>
            Повернутись
          </NavLink>
        )}
        <p className={`${styles['mark']} ${styles['last']}`}>
          {type?.title ?? typeValue ?? 'Усі товари'}
        </p>
      </div>
      {typeValue ? (
        displayProducts.length ? (
          <ul className={styles['list']}>
            {displayProducts.map((obj) => (
              <ProductCard key={obj.id} {...obj} onClick={() => dispatch(addItem(obj.id))} />
            ))}
          </ul>
        ) : (
          <p className={styles['empty']}>List is empty</p>
        )
      ) : (
        <ul className={styles['list']}>
          {types.map((obj) => (
            <ProductCard
              key={obj.id}
              {...obj}
              onClick={() => navigate(`/${routeCreateOrder}/${obj.id}`)}
            />
          ))}
        </ul>
      )}
    </div>
  );
}
