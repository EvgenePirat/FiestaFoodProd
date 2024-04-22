export type Quantity = {
  measurement: string;
  count: number;
  minCount: number;
};

export type IngredientType = {
  id: number;
  title: string;
  quantity: Quantity;
};
