import styles from './ProductCard.module.scss';

interface ProductCardProps {
  title: string;
  image: string;
  onClick?: () => void;
}

export default function ProductCard({ title, image, onClick }: ProductCardProps) {
  return (
    <li className={styles['card']} onClick={onClick}>
      <div className={styles['image-block']}>
        <img className={styles['image']} src={image} alt={title} />
      </div>
      <p className={styles['title']}>{title}</p>
    </li>
  );
}
