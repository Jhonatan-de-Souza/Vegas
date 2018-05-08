
export interface skills {
    id:number,
    name:string,
    description:string,
    attackrange:number

}

export interface fighter {
    id:number,
    name:string,
    power:number,
    speed:number,
    skills:skills[],
    isFinalForm:boolean,
    // DateOfBirth:Date
}

export interface SaveFighter {
  id: number;
  name: string;
  power: number;
  speed: number;
  skills: number[];
  isFinalForm: boolean;
//   DateOfBirth: Date;
}