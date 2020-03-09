//
//  ProductCollectionCellCollectionViewCell.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit
import BeagleUI

class ProductCollectionCell: UICollectionViewCell {
    
    var currentContainerView: UIView?
   
    @IBOutlet weak var labelName: UILabel!
    @IBOutlet weak var labelDescription: UILabel!
    @IBOutlet weak var image: UIImageView!
    @IBOutlet weak var labelPrice: UILabel!
    
    override func sizeThatFits(_ size: CGSize) -> CGSize {
        return size
    }
    
    func setupCell(with product: Product,
                   beagleContext: BeagleContext,
                   renderableDependencies: RenderableDependencies) {
        
        self.contentView.backgroundColor = UIColor(red:0.95, green:0.95, blue:0.95, alpha:1.0)
        self.labelName.text = product.name
        self.labelDescription.text = product.shortDescription
        self.image.image = UIImage(named: "empty")
//        self.image.pathImage(product.imageUrl)
        self.labelPrice.text = product.value
    }
    
}
