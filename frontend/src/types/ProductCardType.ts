export type ProductCardType = {
  id: number;
  title: string;
  image: string;
};

export type ProductType = ProductCardType & { price: number };
