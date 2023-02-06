using GrpcService;

namespace UT_GrpcService;

public static class HandServiceDataV1
{
    public static IEnumerable<object?[]> Data_TestGetHandById()
    {
        yield return new object?[]
        {
            29UL,
            new HandReply
            {
                Id = 29UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 18).ToTimestamp(),
                TakerScore = 567,
                TwentyOne = false,
                Excuse = true,
                Petit = PETIT_RESULT.LostAuBout,
                Chelem = CHELEM.Unknown,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 9UL,
                        Bidding = BIDDING.Garde,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 10UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 12UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 13UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.None
                    }
                }
            }
        };
        yield return new object?[]
        {
            14UL,
            new HandReply
            {
                Id = 14UL,
                Number = 2,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21).ToTimestamp(),
                TakerScore = 567,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.Lost,
                Chelem = CHELEM.AnnouncedSuccess,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 5UL,
                        Bidding = BIDDING.GardeContreLeChien,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 6UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 7UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 8UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    }
                }
            }
        };
        yield return new object?[]
        {
            100UL,
            null
        };
        yield return new object?[]
        {
            0UL,
            null
        };
    }
    
    public static IEnumerable<object?[]> InsertHandData()
    {
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 10UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            new HandReply
            {
                Id = 33UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            -1
        };
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 10UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 7UL,
                        Bidding = BIDDING.Petite,
                        Poignee = POIGNEE.Simple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 8UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 9UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 10UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.None
                    }
                }
            },
            new HandReply
            {
                Id = 33UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 7UL,
                        Bidding = BIDDING.Petite,
                        Poignee = POIGNEE.Simple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 8UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 9UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 10UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.None
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 10UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 0UL,
                        Bidding = BIDDING.Petite,
                        Poignee = POIGNEE.Simple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 8UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 9UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 10UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.None
                    }
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 10UL,
                Number = 5,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 50UL,
                        Bidding = BIDDING.Petite,
                        Poignee = POIGNEE.Simple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 8UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 9UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 10UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.None
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.None
                    }
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 10UL,
                Number = 1,
                Rules = "NewRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            2
        }; 
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 50UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            3
        }; 
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 0UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            3
        };
        yield return new object?[]
        {
            new HandInsertRequest
            {
                GameId = 1UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            3
        };
    }
    
    public static IEnumerable<object?[]> UpdateHandData()
    {
        yield return new object?[]
        {
            new HandReply
            {
                Id = 0UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            3
        };
        yield return new object?[]
        {
            new HandReply
            {
                
                Id = 100UL,
                Number = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 156,
                TwentyOne = false,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.AnnouncedFail
            },
            null,
            3
        };
        yield return new object?[]
        {
            new HandReply
            {
                Id = 3UL,
                Number = 6,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 60,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.Announced
            },
            new HandReply
            {
                Id = 3UL,
                Number = 6,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 60,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.Announced
            },
            -1
        };
        yield return new object?[]
        {
            new HandReply
            {
                Id = 6UL,
                Number = 3,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21).ToTimestamp(),
                TakerScore = 151,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.Owned,
                Chelem = CHELEM.Success,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 12UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.Triple,
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 13UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    }
                }
            },
            new HandReply
            {
                Id = 6UL,
                Number = 3,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21).ToTimestamp(),
                TakerScore = 151,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.Owned,
                Chelem = CHELEM.Success,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 11UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 12UL,
                        Bidding = BIDDING.King,
                        Poignee = POIGNEE.Triple,
                    },
                    new UserBiddingPoignee
                    {
                        PlayerId = 13UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new HandReply
            {
                Id = 3UL,
                Number = 6,
                Rules = "MyRules",
                Date = new DateTime(2023, 01, 19).ToTimestamp(),
                TakerScore = 60,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.AuBout,
                Chelem = CHELEM.Announced
            },
            null,
            2
        };
        yield return new object?[]
        {
            new HandReply
            {
                Id = 6UL,
                Number = 3,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21).ToTimestamp(),
                TakerScore = 151,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.Owned,
                Chelem = CHELEM.Success,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 4UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    }
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new HandReply
            {
                Id = 6UL,
                Number = 3,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21).ToTimestamp(),
                TakerScore = 151,
                TwentyOne = true,
                Excuse = false,
                Petit = PETIT_RESULT.Owned,
                Chelem = CHELEM.Success,
                Biddings =
                {
                    new UserBiddingPoignee
                    {
                        PlayerId = 100UL,
                        Bidding = BIDDING.Opponent,
                        Poignee = POIGNEE.Triple
                    }
                }
            },
            null,
            1
        };
    }

    public static IEnumerable<object?[]> DeleteHandData()
    {
        yield return new object?[]
        {
            23UL,
            true
        };
        yield return new object?[]
        {
            32UL,
            true
        };
        yield return new object?[]
        {
            0UL,
            false
        };
        yield return new object?[]
        {
            50UL,
            false
        };
    }
}
