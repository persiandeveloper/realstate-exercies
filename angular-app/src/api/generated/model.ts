interface Prijs {
    geenExtraKosten: boolean;
    huurAbbreviation: string;
    huurprijs: any;
    huurprijsOpAanvraag: string;
    huurprijsTot: any;
    koopAbbreviation: string;
    koopprijs: number;
    koopprijsOpAanvraag: string;
    koopprijsTot: number;
    originelePrijs: any;
    veilingText: string;
}

interface Project {
    aantalKamersTotEnMet: any;
    aantalKamersVan: any;
    aantalKavels: any;
    adres: any;
    friendlyUrl: any;
    gewijzigdDatum: any;
    globalId: any;
    hoofdFoto: string;
    indIpix: boolean;
    indPDF: boolean;
    indPlattegrond: boolean;
    indTop: boolean;
    indVideo: boolean;
    internalId: string;
    maxWoonoppervlakte: any;
    minWoonoppervlakte: any;
    naam: any;
    omschrijving: any;
    openHuizen: any[];
    plaats: any;
    prijs: any;
    prijsGeformatteerd: any;
    publicatieDatum?: string;
    type: number;
    woningtypen: any;
}

interface PromoLabel {
    hasPromotionLabel: boolean;
    promotionPhotos: any[];
    promotionPhotosSecure: any;
    promotionType: number;
    ribbonColor: number;
    ribbonText: any;
    tagline: any;
}

export interface RealStateObject {
    aangebodenSindsTekst: string;
    aanmeldDatum: string;
    aantalBeschikbaar: any;
    aantalKamers: number;
    aantalKavels: any;
    aanvaarding: string;
    adres: string;
    afstand: number;
    bronCode: string;
    childrenObjects: any[];
    datumAanvaarding: any;
    datumOndertekeningAkte: any;
    foto: string;
    fotoLarge: string;
    fotoLargest: string;
    fotoMedium: string;
    fotoSecure: string;
    gewijzigdDatum: any;
    globalId: number;
    groupByObjectType: string;
    heeft360GradenFoto: boolean;
    heeftBrochure: boolean;
    heeftOpenhuizenTopper: boolean;
    heeftOverbruggingsgrarantie: boolean;
    heeftPlattegrond: boolean;
    heeftTophuis: boolean;
    heeftVeiling: boolean;
    heeftVideo: boolean;
    huurPrijsTot: any;
    huurprijs: any;
    huurprijsFormaat: any;
    id: string;
    inUnitsVanaf: any;
    indProjectObjectType: boolean;
    indTransactieMakelaarTonen: any;
    isSearchable: boolean;
    isVerhuurd: boolean;
    isVerkocht: boolean;
    isVerkochtOfVerhuurd: boolean;
    koopprijs: number;
    koopprijsFormaat: string;
    koopprijsTot: number;
    land: string;
    makelaarId: number;
    makelaarNaam: string;
    mobileURL: string;
    note: any;
    openHuis: any[];
    oppervlakte: number;
    perceeloppervlakte?: number;
    postcode: string;
    prijs: Prijs;
    prijsGeformatteerdHtml: string;
    prijsGeformatteerdTextHuur: string;
    prijsGeformatteerdTextKoop: string;
    producten: string[];
    project: Project;
    projectNaam: any;
    promoLabel: PromoLabel;
    publicatieDatum?: string;
    publicatieStatus: number;
    savedDate: any;
    soort_Aanbod: string;
    soortAanbod: number;
    startOplevering: any;
    timeAgoText: any;
    transactieAfmeldDatum: any;
    transactieMakelaarId: any;
    transactieMakelaarNaam: any;
    typeProject: number;
    uRL: string;
    verkoopStatus: string;
    wGS84X: number;
    wGS84Y: number;
    woonOppervlakteTot: number;
    woonoppervlakte: number;
    woonplaats: string;
    zoekType: number[];
}