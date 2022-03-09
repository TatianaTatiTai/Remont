export class EducationInfo {
  constructor(
    public Id: string,
    public UserId: string,

    public Education: string,

    public EducationType: string,
    public Institution: string,

    public Faculty: string,
    public Speciality: string,
    public End: string,
    public AnotherInfo: string,

    public CreateDate: string,
    public Status: string

  ) { }
}
