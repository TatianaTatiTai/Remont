export class Order {
  constructor(
    public Id: string,
    public UserId: string,
    public Fio: string,
    public Phone: string,

    public Description: string,

    public NeedEvaluation: boolean,
    public Status: string
  ) {}

}
