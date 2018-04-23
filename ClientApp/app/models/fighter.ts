
export interface skills{
    id:number,
    name:string,
    description:string,
    attackpower:number,
    attackrange:number

}

export interface fighter{
    id:number,
    name:string,
    power:number,
    speed:number
    skills:skills[]
}