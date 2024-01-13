package  ma.zs.stocky.dao.specification.core.stock;

import ma.zs.stocky.dao.criteria.core.stock.ProduitCriteria;
import ma.zs.stocky.bean.core.stock.Produit;
import ma.zs.stocky.zynerator.specification.AbstractSpecification;


public class ProduitSpecification extends  AbstractSpecification<ProduitCriteria, Produit>  {

    @Override
    public void constructPredicates() {
        addPredicateId("id", criteria);
        addPredicate("reference", criteria.getReference(),criteria.getReferenceLike());
        addPredicate("libelle", criteria.getLibelle(),criteria.getLibelleLike());
        addPredicate("barcode", criteria.getBarcode(),criteria.getBarcodeLike());
        addPredicateBigDecimal("prixAchatMoyen", criteria.getPrixAchatMoyen(), criteria.getPrixAchatMoyenMin(), criteria.getPrixAchatMoyenMax());
        addPredicateBigDecimal("quantite", criteria.getQuantite(), criteria.getQuantiteMin(), criteria.getQuantiteMax());
        addPredicateBigDecimal("seuilAlert", criteria.getSeuilAlert(), criteria.getSeuilAlertMin(), criteria.getSeuilAlertMax());
    }

    public ProduitSpecification(ProduitCriteria criteria) {
        super(criteria);
    }

    public ProduitSpecification(ProduitCriteria criteria, boolean distinct) {
        super(criteria, distinct);
    }

}
