
export interface skills {
    id:number,
    name:string,
    description:string,
    attackrange:number

}

export interface Fighter {
    id:number,
    name:string,
    power:number,
    speed:number,
    skills:skills[],
    isFinalForm:boolean,
    DateOfBirth:string
}

export interface SaveFighter {
  id: number;
  name: string;
  power: number;
  speed: number;
  skills: number[];
  isFinalForm: boolean;
  DateOfBirth: string;
}