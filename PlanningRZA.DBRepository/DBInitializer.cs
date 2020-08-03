using Microsoft.EntityFrameworkCore;
using PlanningRZA.Models;
using PlanningRZA.Models.Enums;
using PlanningRZA.Models.Equipments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.DBRepository
{
	public static class DbInitializer
	{
        public async static Task Initialize(RepositoryContext context)
        {
            await context.Database.MigrateAsync();

            var branchesCount = await context.Branches.CountAsync().ConfigureAwait(false);

            if (branchesCount == 0)
            {
                context.Branches.AddRange(
                new Branch
                {
                    Direction = BranchDirection.Electical,
                    Name = "Пинские ЭС",
                    Substations = new List<Substation>
                    {
                        new Substation
                        {
                            Area="Дрогичинский РЭС",
                            Name="Дрогичин",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new Transformer
                                {
                                    Name="Т-1",
                                    Power=10000,
                                    PrimaryVoltage=VoltLevel._110kV,
                                    SecondaryVoltage=VoltLevel._35kV,
                                    TertiaryVoltage=VoltLevel._10kV,
                                    QuarternaryVoltage=VoltLevel.none,
                                    YearOfProduction=1960
                                },
                                new Breaker
                                {
                                    Appointment=BreakerAppointment.Coupling,
                                    Name="СВ-110",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=2010,
                                    Type=BreakerType.SF6
                                }
                            }
                        },
                        new Substation
                        {
                            Area="Пинский городской РЭС",
                            Name="Пинск-Северная",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new CurrentTransformer
                                {
                                    Name="Трансформатор тока 110 кВ Т-1",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=1980,
                                    CountOfPoles=3,
                                    CountOfSecondaryWinding=4,
                                    PrimaryCurrent=200,
                                    SecondaryCurrent=5
                                },
                                new VoltageTransformer
                                {
                                    Name="ТН 110 кВ 1 секции шин",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=2000,
                                    CountOfSecondaryWinding=2,
                                    HasOpenedTriangle=true
                                }
                            }
                        }
                    }
                },
                new Branch
                {
                    Direction = BranchDirection.Heat,
                    Name = "Пинские ТС",
                    Substations = new List<Substation> {

                        new Substation
                        {
                            Area="Пинская ТЭЦ",
                            Name="ОРУ 110 кВ",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new Transformer
                                {
                                    Name="Т-2",
                                    Power=25000,
                                    PrimaryVoltage=VoltLevel._110kV,
                                    SecondaryVoltage=VoltLevel._10kV,
                                    TertiaryVoltage=VoltLevel._10kV,
                                    QuarternaryVoltage=VoltLevel.none,
                                    YearOfProduction=1975
                                },
                                new Breaker
                                {
                                    Appointment=BreakerAppointment.Coupling,
                                    Name="СВ-110 кВ",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=1955,
                                    Type=BreakerType.Oil
                                }
                            }
                        },
                        new Substation
                        {
                            Area="Западная мини ТЭЦ",
                            Name="РУ 10 кВ",
                            VoltageLevel=VoltLevel._10kV,
                            Equipments= new List<Equipment>
                            {
                                new CurrentTransformer
                                {
                                    Name="Трансформатор тока 10 кВ ввода №1",
                                    PrimaryVoltage=VoltLevel._10kV,
                                    YearOfProduction=1990,
                                    CountOfPoles=2,
                                    CountOfSecondaryWinding=2,
                                    PrimaryCurrent=100,
                                    SecondaryCurrent=5
                                },
                                new VoltageTransformer
                                {
                                    Name="ТН 10 кВ 1 секции шин",
                                    PrimaryVoltage=VoltLevel._10kV,
                                    YearOfProduction=2000,
                                    CountOfSecondaryWinding=2,
                                    HasOpenedTriangle=true
                                }
                            }
                        }
                    }
                });
                context.SaveChanges();
            }
        }
	}
}
